using System;

namespace Project{
    internal class Program{
        
        // Tạo một số nguyên ngẫu nhiên trong phạm vi từ 2 đến 10000.
        static ulong RandomNumberGenerator(){
            Random r = new Random();
            int a = r.Next(2,10000);
            return (ulong)a;
        }
        

        // Tìm ước chung lớn nhất của 2 số nguyên.
        static ulong GCFFinder(ulong a, ulong b){
            if(a == b || a % b == 0){
              return b;  
            }else{
                ulong gcf;
                do{
                    gcf = a % b;
                    a = b;
                    b = gcf;
                }while(a % b != 0);
                return gcf;
            }
        }


        // Tìm bội chung nhỏ nhất của 2 số nguyên 
        static ulong LCMFinder(ulong a, ulong b){
            ulong lcm = a*b/ GCFFinder(a,b);
            return lcm; 
        }


        // Kiểm tra xem 1 số nguyên có phải là số nguyên tố hay không.
        static bool PrimeNumberChecker(ulong a){

            ulong n = 10000;
            bool prime = true;
            bool[] isPrime = new bool[n + 1];
            for (ulong i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

            for (ulong i = 0; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (ulong j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }

            }

            for (ulong i = 0; i <= n; i++)
            {
                if (isPrime[i])
                {
                    if(a == i){
                        prime = true;
                        break;
                    }else{
                        prime = false;
                    }
                }
            }

            return prime;

        }
        

        // Khởi tạo khóa e ngẫu nhiên đáp ứng điều kiện.
        static ulong EGen(ulong p, ulong q){
            ulong e;
            while(true){
                ulong a = RandomNumberGenerator();
                if(2 < a && a < LCMFinder(p - 1, q - 1) && GCFFinder(a, (p - 1)*(q-1)) == 1){
                    e = a;
                    break;
                }
            }
            return e;
        }
        

        // Khởi tạo 2 số nguyên tố p và q ngẫu nhiên.
        static ulong PnQGenerator(){           
            ulong d; 
            while(true){
                ulong a = RandomNumberGenerator();
                if(PrimeNumberChecker(a) == true){
                    d = a;
                    break;
                }
            }
            return d;
        }

        static void Main(string[] args){
            ulong p = PnQGenerator();
            ulong q = PnQGenerator();
            ulong e = EGen(p, q);
            
            ulong n = p*q;

            Console.WriteLine($"Key n: {n}");
            Console.WriteLine($"Key e: {e}");
        }
    }
}