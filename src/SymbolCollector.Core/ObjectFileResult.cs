using System.Collections.Generic;

namespace SymbolCollector.Core
{
    public class ObjectFileResult
    {
        public string BuildId { get; }
        public string Path { get; }
        public BuildIdType BuildIdType { get; }
        public FileFormat FileFormat { get; set; }
        public Architecture Architecture { get; set; }
        public ObjectFileType ObjectFileType { get; set; }
        public string Hash { get; set; }

        public ObjectFileResult(
            string buildId,
            string path,
            string hash,
            BuildIdType buildIdType)
        {
            BuildId = buildId;
            Path = path;
            Hash = hash;
            BuildIdType = buildIdType;
        }
    }

    public enum BuildIdType
    {
        None,
        GnuBuildId,
        Uuid,
        TextSectionHash,
    }

    public class FatMachOFileResult : ObjectFileResult
    {
        public IEnumerable<ObjectFileResult> InnerFiles { get; }

        public FatMachOFileResult(
            string buildId,
            string path,
            string hash,
            BuildIdType buildIdType,
            IEnumerable<ObjectFileResult> innerFiles)
            : base(buildId, path, hash, buildIdType)
            => InnerFiles = innerFiles;
    }
}
