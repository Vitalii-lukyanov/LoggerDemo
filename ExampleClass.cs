using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    public class ExampleClass
    {
        public ExampleClass()
        {
            Delimoe = 10;
            Delitel = 0;
        }
        //private  Logger logger;
        public Int32 Delimoe { get; set; }
        public Int32 Delitel { get; set; }
        public Int32 Chastnoe { get; set; }
        

        public void  Devide()
        {
            
            try
            {
                Chastnoe = Delimoe / Delitel;
            }
            catch(Exception e)
            {
                var logger = Logger.GetInctance();
                logger.writeLogAsync(e);
            }
            
            
        }
        public async Task DevideAsync()
        {
            await Task.Run(Devide);

        }

    }

    public class ExampleClass2
    {
        public ExampleClass2()
        {
            
        }
        //private static Logger logger;
        private int[] mass = new int[3];
        public void OutOfRange()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                    mass[i] = i;
            }
            catch (Exception e)
            {
                var logger = Logger.GetInctance();
                logger.writeLogAsync(e);
            }
        }

        public async Task OutOfRange2()
        {
            await Task.Run(OutOfRange);
        }
    }
}
