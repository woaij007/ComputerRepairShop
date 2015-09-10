using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ComputerRepairShop.Models
{
  public class CommentsContextInitializer : DropCreateDatabaseIfModelChanges<CommentContext>
  {
    protected override void Seed(CommentContext context)
    {
      var comments = new List<Comment>()            
            {
                new Comment() { Question = "Where is my computer?", Answer = "On the way home.", UserName = "woaij008", Email = "maojun0609@qq.com" },
                new Comment() { Question = "Where is my keyboard?", Answer = "On the way home.", UserName = "woaij009", Email = "maojun4518@qq.com" },
            };

      comments.ForEach(p => context.Comments.Add(p));
      context.SaveChanges();
    }
  }
}