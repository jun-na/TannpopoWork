using System;
using System.Collections.Generic;
using System.Text;

namespace TannpopoWork {
    class Syain : IObserver<Sashimi> {
        public string Name;
        public string Age;

        public void OnCompleted() {
            throw new Exception("終わりなどない");
        }

        public void OnError(Exception error) {
            throw new Exception("単純作業にエラーなどない");
        }

        public void OnNext(Sashimi value) {
            OnNextChild(value);
        }

        protected virtual void OnNextChild(Sashimi value) {
            value.OnTanpopo(this);
        }
    }
}
