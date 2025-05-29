using Microsoft.EntityFrameworkCore;
using VSHCTwebApp.Data;
using VSHCTwebApp.Models;

namespace VSHCTwebApp.Services
{
    public class ProfileService
    {
        private readonly ApplicationDbContext _context;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile?> GetUserProfileAsync(string userId)
        {
            return await _context.UserProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == userId);
        }

        public async Task<List<UserProfile>> GetAllProfilesAsync()
        {
            return await _context.UserProfiles
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
