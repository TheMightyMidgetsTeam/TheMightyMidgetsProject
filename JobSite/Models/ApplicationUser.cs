using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web;

namespace JobSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [StringLength(100)]
        public string FullName { get; set; }

        public byte[] Photo { get; set; }

        //   public System.DateTime BirthDate { get; set; } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<File> Files { get; set; }
        public static void AddPhotoToUser(HttpPostedFileBase upload, ApplicationUser user)
        {
            user.AddFileToUser(upload, FileType.Photo);
        }
        public void AddFileToUser(HttpPostedFileBase upload, FileType ft)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var file = new File
                {
                    FileName = System.IO.Path.GetFileName(upload.FileName),
                    FileType = ft,
                    ContentType = upload.ContentType
                };
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    file.Content = reader.ReadBytes(upload.ContentLength);
                }
                if (this.Files == null)
                {
                    this.Files = new List<File> { file };
                }
                else this.Files.Add(file);
                if (ft == FileType.Photo)
                {
                    this.Photo = file.Content;
                }

            }

        }
    }
}