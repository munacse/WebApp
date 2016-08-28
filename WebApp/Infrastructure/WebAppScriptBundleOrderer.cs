using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApp.Infrastructure
{
    public class WebAppScriptBundleOrderer : IBundleOrderer
    {
        private const string FirstFile = "index";

        public IEnumerable<BundleFile> OrderFiles(
            BundleContext context,
            IEnumerable<BundleFile> files)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            var fileList = files.ToList();

            var indexFiles = fileList.Where(f =>
                    FirstFile.Equals(
                        GetExtentionlessFilename(f),
                        StringComparison.OrdinalIgnoreCase))
                .Select(f =>
                    new
                    {
                        file = f,
                        rank = f.IncludedVirtualPath.Split(
                                  new[] { '/', '\\' },
                                  StringSplitOptions.RemoveEmptyEntries).Length
                    })
                .OrderByDescending(x => x.rank)
                .ThenBy(x => x.file.IncludedVirtualPath, comparer)
                .Select(x => x.file)
                .ToList();

            var otherFiles = fileList.Except(indexFiles)
                .OrderByDescending(f => f.IncludedVirtualPath, comparer);

            var orderedList = indexFiles.Concat(otherFiles).ToList();

            return orderedList;
        }

        private static string GetExtentionlessFilename(BundleFile file)
        {
            var fullPath = file.IncludedVirtualPath;
            var fileName = VirtualPathUtility.GetFileName(fullPath);
            var extentionlessName = Path.GetFileNameWithoutExtension(fileName);

            return extentionlessName;
        }
    }
}