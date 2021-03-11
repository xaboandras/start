using AttaxxPlus.Model;
using System;

namespace AttaxxPlus.Boosters
{
    /// <summary>
    /// Booster filling all empty fields with the opponents' color (assuming 2 players).
    /// </summary>
    public class SurrenderBooster : BoosterBase
    {
        // EVIP: compact override of getter for Title returning constant.
        public override string Title => "Surrender";

        public SurrenderBooster() : base() { }

        public override void InitializeGame() => LoadImage(new Uri("ms-appx:///Boosters/SurrenderBooster.png"));

        public override bool TryExecute(Field selectedField, Field currentField)
        {
            int winnerPlayer;

            if (GameViewModel.CurrentPlayer == 1)
                winnerPlayer = 2;
            else
                winnerPlayer = 1;

            foreach (var field in GameViewModel.Model.Fields)
                field.Owner = winnerPlayer;
            
            GameViewModel.EndOfTurn();
            return true;
        }
    }
}
