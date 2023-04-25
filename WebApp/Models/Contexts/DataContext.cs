using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Models.Contexts;

public class DataContext : DbContext
{
    #region constructors
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    #endregion

    #region entities
    public DbSet<FeedbackEntity> Feedbacks { get; set; }

    #endregion
}
