using Microsoft.AspNetCore.Builder;

namespace IleriWebProje.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                // Platforms
                if (!context.Platforms.Any()) 
                {

                }

                // Mentor
                if (!context.Mentors.Any())
                {

                }
                // Skill_Organizer
                if (!context.Skill_Organizers.Any())
                {

                }
                // Skills
                if (!context.Skills.Any())
                {

                }
                // Mentors & Skills
                if (!context.Mentors_Skills.Any())
                {

                }
            }
        }
    }
}
