using System;
using System.Collections.Generic;
using System.Text;

namespace TannpopoWork {
    class HakenSyain : Syain{
        protected override void OnNextChild(Sashimi value) {
            value.OnTanpopo(this);
            value.OnTanpopo(this);
            value.OnTanpopo(this);
            value.OnTanpopo(this);
            value.OnTanpopo(this);
        }

    }
}
