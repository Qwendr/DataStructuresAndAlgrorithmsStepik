namespace Drunkard
{
    public class Program
    {
        static Queue<int> queueTop = new Queue<int>();
        static Queue<int> queueBottom = new Queue<int>();

        static void Main(string[] args)
        {

            FillTop();
            FillBottom();
            string winner = Play();
            Console.WriteLine(winner);
        }
        static void FillTop()
        {
            foreach (string number in Console.ReadLine().Split())
            {
                queueTop.Enqueue(int.Parse(number));
            }
        }
        static void FillBottom()
        {
            foreach (string number in Console.ReadLine().Split())
            {
                queueBottom.Enqueue(int.Parse(number));
            }
        }

        static string Play()
        {
            int count = 0;
            while(count < 1000000)
            {
                if (TopPlayerHasNoCards())
                    return $"second {count}";
                if (BottomPlayerHasNoCards())
                    return $"first {count}";
                GiveCardToWinner();
                count++;
            }
            return "botva";
        }

        static void GiveCardToWinner()
        {
            if(!IsTopCardIsNineAndBottomIsZero() &&
                queueTop.Peek() > queueBottom.Peek() || IsBottomCardIsNineAndTopIsZero())
            {
                int topCard = queueTop.Dequeue();
                int bottomCard = queueBottom.Dequeue();
                queueTop.Enqueue(topCard);
                queueTop.Enqueue(bottomCard);
            }
            else if(!IsBottomCardIsNineAndTopIsZero() &&
                queueBottom.Peek() > queueTop.Peek() || IsTopCardIsNineAndBottomIsZero())
            {
                int topCard = queueTop.Dequeue();
                int bottomCard = queueBottom.Dequeue();
                queueBottom.Enqueue(bottomCard);
                queueBottom.Enqueue(topCard);
            }
        }
        static bool IsTopCardIsNineAndBottomIsZero()
        {
            return queueTop.Peek() == 9 && queueBottom.Peek() == 0;
        }
        static bool IsBottomCardIsNineAndTopIsZero()
        {
            return queueTop.Peek() == 0 && queueBottom.Peek() == 9;
        }

        static bool TopPlayerHasNoCards()
        {
            return queueTop.Count == 0;
        }
        static bool BottomPlayerHasNoCards()
        {
            return queueBottom.Count == 0;
        }
    }
}