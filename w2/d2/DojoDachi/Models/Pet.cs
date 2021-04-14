using System;
using Microsoft.AspNetCore.Http;

namespace DojoDachi.Models
{
    public class Pet
    {
        public int Happiness { get; set; }
        public int Fullness { get; set; }
        public int Meals { get; set; }
        public int Energy { get; set; }
        public string State
        {
            get
            {
                if (Fullness < 0 || Happiness < 0)
                {
                    return "Lose";
                }

                if (Energy >= 100 && Fullness >= 100 && Happiness >= 100)
                {
                    return "Win";
                }

                return "Playing";
            }
            set { }
        }

        public Pet()
        {
            Happiness = 20;
            Fullness = 20;
            Meals = 3;
            Energy = 50;
        }

        public string Feed(ISession session)
        {
            if (Meals > 0)
            {
                Meals -= 1;

                if (RandomlyDislikes() == false)
                {
                    Fullness += new Random().Next(5, 11);
                }
            }

            UpdateSession(session);
            return State;
        }

        public string Play(ISession session)
        {
            Energy -= 5;

            if (RandomlyDislikes() == false)
            {
                Happiness += new Random().Next(5, 11);
            }

            UpdateSession(session);
            return State;
        }

        public string Work(ISession session)
        {
            Energy -= 5;
            Meals += new Random().Next(1, 4);

            UpdateSession(session);
            return State;
        }

        public string Sleep(ISession session)
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;

            UpdateSession(session);
            return State;
        }

        public void UpdateSession(ISession session)
        {
            session.SetObjectAsJson("Pet", this);
            session.SetString("GameStatus", State);
        }

        public bool RandomlyDislikes()
        {
            return new Random().Next(1, 5) == 1;
        }
    }
}