using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace benchmark
{
    [SimpleJob(runtimeMoniker: RuntimeMoniker.Net471)]
    [SimpleJob(runtimeMoniker: RuntimeMoniker.NetCoreApp31)]
    [SimpleJob(runtimeMoniker: RuntimeMoniker.Net60)]
    [SimpleJob(runtimeMoniker: RuntimeMoniker.Net70)]
    public class SealedTest
    {
        private SealedType _sealed = new SealedType();
        private NonSealedType _nonSealed = new NonSealedType();

        //[Benchmark(Baseline = true)]
        public int NonSealed() => _nonSealed.M() + 42;

        //[Benchmark]
        public int Sealed() => _sealed.M() + 42;
    }

    public class BaseType
    {
        public virtual int M() => 1;
    }

    public class NonSealedType : BaseType
    {
        public override int M() => 2;
    }

    public sealed class SealedType : BaseType
    {
        public override int M() => 2;
    }
}
