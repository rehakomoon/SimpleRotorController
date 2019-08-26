using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotorController
{
    class Program
    {
        async static void SendMessageLoop()
        {
            RotorController rp = new RotorController("HakoDev_waki", 10);

            var dummy_data = new byte[16];
            dummy_data[0] = 255;

            await rp.SetupAsync();

            while (true)
            {
                for (byte i = 0; i <= 255; ++i)
                {
                    dummy_data[1] = i;
                    await rp.SendMessage(dummy_data, false);
                }
            }

        }

        static void Main(string[] args)
        {
            var sm = Task.Run(() => SendMessageLoop());

            while(true)
            {
                Task.Delay(1000);
            }
        }
    }
}
