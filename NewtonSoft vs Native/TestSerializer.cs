using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace NewtonSoft_vs_Native;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
public class TestSerializer
{
    [Params(1, 100)]
    public int N;

    [Benchmark]
    public void SerialicerWithNewtonSoft() =>
        Newtonsoft.Json.JsonConvert.SerializeObject(People.getPeoples(N));

    [Benchmark]
    public void SerialicerWithMicrosoft() =>
        System.Text.Json.JsonSerializer.Serialize(People.getPeoples(N));

    [Benchmark]
    public void DeserilicerWithNewtonSoft() =>
            Newtonsoft.Json.JsonConvert.DeserializeObject<List<People>>(People.GetJsonFile(N));

    [Benchmark]
    public void DeserealiceWithMicrosoft() =>
        System.Text.Json.JsonSerializer.Deserialize<List<People>>(People.GetJsonFile(N));


}
