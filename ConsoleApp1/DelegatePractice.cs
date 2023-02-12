using System;

namespace DelegatePractice
{
    public class CarDriver
    {
        public static void GoForward() => Console.WriteLine("직진");
        public static void GoLeft() => Console.WriteLine("좌회전");
        public static void GoRight() => Console.WriteLine("우회전");
    }

    public class Insa
    {
        public void Bye() => Console.WriteLine("잘가");

        // 대리자 생성: 의미상으로 대리운전, class와 같은 레벨로 생성해도 됨
        public delegate void GoHome();

        public class DelegatePractice
        {
            // 대리자 형식 선언: 메서드를 묶을 별칭, 클래스 내부에도 생성 가능
            public delegate void Say();

            private static void Hello() { Console.WriteLine("Hello"); }
            private static void Hi() { Console.WriteLine("Hi"); }

            static void Main(string[] args)
            {
                // 메서드는 따로따로 호출
                CarDriver.GoLeft();
                CarDriver.GoForward();
                CarDriver.GoRight();

                // 대리자를 사용한 메서드 등록 및 호출
                GoHome go = new GoHome(CarDriver.GoLeft);
                go += new GoHome(CarDriver.GoForward);
                go += new GoHome(CarDriver.GoRight);
                go += new GoHome(CarDriver.GoLeft); // 등록
                go -= new GoHome(CarDriver.GoLeft); // 취소
                go();

                Console.WriteLine();

                Say say;
                say = new Say(Hi);
                say += new Say(Hello);
                say();

                Insa insa = new Insa();
                Say say2 = new Say(insa.Bye);
                say2 += new Say(insa.Bye);
                say2();
            }
        }
    }
}