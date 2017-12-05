using Microsoft.AspNetCore.Hosting;

namespace AI.BLL.Helpers
{
    public static class PathHelper {
        public static string GetParentFolder(IHostingEnvironment env) {

            var parentfolder = env.ContentRootPath.Replace(env.ApplicationName, "AI.DAL");

            return parentfolder;
        }
    }
}