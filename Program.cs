using System;
using System.Threading;
using System.Threading.Tasks;

namespace tannpopo {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("終了するには q を押してください。");
            var factory = new Factory();
            var syain1 = new Syain() { Name = "ベテラン社員１", Age = "45" };
            var syain2 = new Syain() { Name = "若手社員2", Age = "19" };
            var syain3 = new Syain() { Name = "再雇用３", Age = "77" };
            factory.Subscribe(syain1);
            factory.Subscribe(syain2);
            factory.Subscribe(syain3);

            var source = new CancellationTokenSource();
            var task = Task.Run(() => {
                var token = source.Token;
                for (; ; ) {
                    if (token.IsCancellationRequested) {
                        token.ThrowIfCancellationRequested();
                    }
                    factory.Business();
                    Console.WriteLine("");
                    Thread.Sleep(1500);
                }
            });
            for (; ; ) {
                var key = Console.ReadKey();
                if (key.KeyChar == 'q') {
                    source.Cancel();
                    task.Wait();
                    break;
                }
            }
        }
    }
}
