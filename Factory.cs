using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tannpopo {
    class Factory : IObservable<Sashimi> {
        private List<IObserver<Sashimi>> list = new List<IObserver<Sashimi>>();

        public IDisposable Subscribe(IObserver<Sashimi> observer) {
            list.Add(observer);
            return new Disposer(observer, list);
        }

        public void Business() {
            Parallel.ForEach(list, (a) => a.OnNext(new Sashimi()));
        }

        private class Disposer :IDisposable{
            private IObserver<Sashimi> observer;
            private List<IObserver<Sashimi>> observers;

            public Disposer(IObserver<Sashimi> observer, List<IObserver<Sashimi>> observers) {
                this.observer = observer;
                this.observers = observers;
            }

            public void Dispose() {
                observers.Remove(observer);
            }

        }
    }
}
