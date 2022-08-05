using System;
using System.Linq;
using System.Threading;

namespace CSharp_Second
{
    internal class Program
    {
        static void start_question(in string[] questions, in string[][] answers, out int score)
        {

            score = 0;

            int[] correct_answers = new int[10];
            int[] incorrect_answers = new int[10];
            int ans = default;
            for (int i = 0; i < questions.Length; i++)
            {
                Console.Clear();
                for (int j = 0; j < ans; j++)
                {
                    if (correct_answers[j] - 1 == j)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (incorrect_answers[j] - 1 == j)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"{j + 1}) {questions[j]}\n");
                    Console.WriteLine($"a) {answers[j][0]}");
                    Console.WriteLine($"b) {answers[j][1]}");
                    Console.WriteLine($"c) {answers[j][2]}");
                }

                Console.ForegroundColor = ConsoleColor.White;

                int[] exists = new int[3];
                Console.WriteLine($"{i + 1}){questions[i]}\n");
                int k = default;
                Random rand = new Random();
                while (k != exists.Length)
                {
                    int rand_var = rand.Next(1, 4);
                    bool flag = true;

                    foreach (var item in exists)
                        if (item.Equals(rand_var))
                            flag = false;

                    if (flag)
                        exists[k++] = rand_var;
                }
                Console.WriteLine(answers[i][exists[0] - 1]);
                Console.WriteLine(answers[i][exists[1] - 1]);
                Console.WriteLine(answers[i][exists[2] - 1]);
                Console.WriteLine();

                string? answer;

                Console.Write("Choose Variant: ");
                answer = Console.ReadLine();


                if (answer == "a" && answers[i][0] == answers[i][exists[0] - 1])
                {
                    score += 10;
                    correct_answers[ans++] = i + 1;
                }
                else if (answer == "b" && answers[i][0] == answers[i][exists[1] - 1])
                {
                    score+=10;
                    correct_answers[ans++] = i + 1;
                }
                else if (answer == "c" && answers[i][0] == answers[i][exists[2] - 1])
                {
                    score+=10;
                    correct_answers[ans++] = i + 1;
                }
                else
                {
                    score-=10;
                    incorrect_answers[ans++] = i + 1;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string[] questions = new string[10] {
                "Həkiminiz sizə 3 ədəd dərman verir və bunlari yarim saat araliqla atmanizi məsləhət gorur\ndərmanlarin hamisini bitirməniz ucun sizə nə qədər vaxt lazimdır?",
                "Bircə kibritiniz var, qaranlıq və soyuq otağa girirsiniz, orada çıraq, qaz sobası, şam var.\nHansını ilk yandırırsınız?",
                "6:2(1+2) =?",
                "Gün boyunca saat və dəqiqə əqrəbləri neçə dəfə üst-üstə düşür?",
                "Zəfərin atasının 5 övladı var. Onlardan 4-nün adı sırasıyla Zeze, Zizi, Zözö, Zuzudur.\n5-ci uşağın adı nədir?",
                "Bəzi aylar 30, bəziləri 31; neçə ayda 28 gün var ?",
                "Sizə aid olsa da, başqalarının sizdən çox istifadə etdiyi nədir?",
                "Bir qaçış yarışında ikincini sollayıb keçirsiniz, nəticədə siz necənci olursunuz?",
                "Evin bağçasındakı otlar hər gün əvvəlki gündən iki dəfə çox böyüyür.\nOt 10 günə bütün bağı örtürsə, hansı gündə onun yarısını örtəcək?",
                "5 maşın 5 dəqiqədə 5 düymə istehsal edərsə,100 maşın 100 düyməni nə qədər müddətdə istehsal edər?",
            };

            string[][] answers = new string[10][];
            answers[0] = new string[3] { "1 saat", "2 saat", "1 saat 30 deqiqe" };
            answers[1] = new string[3] { "Kibrit", "Çırağı", "Qaz Sobasın" };
            answers[2] = new string[3] { "9", "1", "3" };
            answers[3] = new string[3] { "22", "6", "12" };
            answers[4] = new string[3] { "Zefer", "Zaza", "Zamir" };
            answers[5] = new string[3] { "12", "1", "6" };
            answers[6] = new string[3] { "Adiniz", "Koyneyiniz", "Çaxmağınız" };
            answers[7] = new string[3] { "2-ci", "1-ci", "4-cu" };
            answers[8] = new string[3] { "9", "5", "2" };
            answers[9] = new string[3] { "20 deqiqe", "5 deqiqe", "100 deqiqe" };

            int score = 0;
            start_question(questions, answers, out score);

            if (score < 0) score = 0;

            Console.WriteLine($"Your Score: {score}");

        }
    }
}
