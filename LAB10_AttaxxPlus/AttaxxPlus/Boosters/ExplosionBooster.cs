using AttaxxPlus.Model;
using System;

namespace AttaxxPlus.Boosters
{
    public class ExplosionBooster : BoosterBase
    {
        private int usableCounterPlayer1 = 1;
        private int usableCounterPlayer2 = 1;

        public ExplosionBooster() : base() { }

        public override string Title 
        { 
            get 
            {
                if (GameViewModel.CurrentPlayer == 1)
                    return $"Explosion ({usableCounterPlayer1})";
                return $"Explosion ({usableCounterPlayer2})";
            } 
        }

        public override void InitializeGame()
        {
            LoadImage(new Uri("ms-appx:///Boosters/ExplosionBooster.png")); // No copyright image, source: https://pixabay.com/images/id-2025548/
            usableCounterPlayer1 = 1;
            usableCounterPlayer2 = 1;
        }

        protected override void CurrentPlayerChanged()
        {
            base.CurrentPlayerChanged();
            Notify(nameof(Title));
        }

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            if (GameViewModel.CurrentPlayer == 1 && usableCounterPlayer1 > 0)
            {
                usableCounterPlayer1--;
                Notify(nameof(Title));
                Explosion(selectedField);
                return true;
            }
            else if (GameViewModel.CurrentPlayer == 2 && usableCounterPlayer2 > 0)
            {
                usableCounterPlayer2--;
                Notify(nameof(Title));
                Explosion(selectedField);
                return true;
            }
            return false;
        }

        private void Explosion(Field selectedField)
        {
            if (selectedField.Owner == GameViewModel.CurrentPlayer)
            {
                foreach (Field field in GameViewModel.Model.Fields)
                {
                    if (field.Row == selectedField.Row || field.Column == selectedField.Column)
                        field.Owner = 0;
                }
            }
        }
    }
}
