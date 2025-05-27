namespace ecommerce.auth_ecommerce.Services
{
    public class AuthService
    {
		private readonly EcomContext _context;
		private readonly IConfiguration _configuration;
		public AuthService(EcomContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public async Task<ServiceResponse<int>> Register (Utenti utenti, string password)
		{
			var response = new ServiceResponse<int>();
			if(await UserExists(utenti.Username))
			{
				response.Message = "Utente già registrato";
				response.Success = false;
				return response;
			}
			
			CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            utenti.PasswordHash = passwordHash;
            utenti.PasswordSalt = passwordSalt;

			_context.Utenti.Add(utenti);
			await _context.SaveChangesAsync();
			//imposta la variabile globale che indica l'identificativo dell utente ID
            
            response.Data = utenti.Id;
            response.Success = true;
            response.Message = "Utente registrato con successo.";
            
            return response;
		}

		public async Task<ServiceResponse<string>> Login(string username, string password)
		{
			var response = new ServiceResponse<string>();
			var utente = await _context.Utenti
				.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
			if (utente is null)
			{
				response.Success = false;
				response.Message = "User not found";
			}
			else if(!VerifyPasswordHash(password, utente.PasswordHash, utente.PasswordSalt))
			{
				response.Success = false;
				response.Message = "Wrong password";
			}
			else
			{
				response.Data = CreateToken(utente);
			}
			//imposta la variabile globale che indica l'identificativo dell utente ID
			return response;
		}

		public async Task<bool> UserExists(string username)
		{
			return await _context.Utenti.AnyAsync( c => c.Username.ToLower() == username.ToLower());
		}

		
		// Metodo per creare l'hash della password
		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			}
		}
		
		// Metodo per creare il token JWT
		private string CreateToken(Utenti utenti)
		{
			if (string.IsNullOrEmpty(_configuration.GetSection("AppSettings:Token").Value))
			{
				throw new InvalidOperationException("Il valore del token non è configurato correttamente.");
			}

			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, utenti.Id.ToString()),
				new Claim(ClaimTypes.Name, utenti.Username)
			};

			SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

			SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = creds
			};

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}

		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computedHash.SequenceEqual(passwordHash);
			}
		}
    }
}

