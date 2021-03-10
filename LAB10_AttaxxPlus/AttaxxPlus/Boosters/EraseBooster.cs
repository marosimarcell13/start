using System;
using AttaxxPlus.Model;

namespace AttaxxPlus.Boosters
{
    //Szorgalmi feladat:Egy további booster elkészítése, ami az éppen kijelölt mezőre hat (de csak ha a saját játékosé). Abban a sorban és oszlopban minden mezőt üresre állít. Ez a booster minden játékosnak csak egyszer működjön!
    public class EraseBooster : BoosterBase
    {
        public override string Title { get => $"Erase ({usableCounter[this.GameViewModel.CurrentPlayer]})"; }
        private int[] usableCounter = { 0, 1, 1 };
        protected override void CurrentPlayerChanged()
        {
            base.CurrentPlayerChanged();
            Notify(nameof(this.Title));
        }
        public EraseBooster() : base()
        {
            //Sajnos olyan képet amit sikerül megjeleníteni nem készítettem
            LoadImage(new Uri(@"ms-appx:///Boosters/EraseBooster.png"));
        }
        public override bool TryExecute(Field selectedField, Field currentField)
        {
            if (usableCounter[this.GameViewModel.CurrentPlayer] > 0 && !(selectedField == null))
            {
                usableCounter[this.GameViewModel.CurrentPlayer]--;
                Notify(nameof(Title));
                for (int i = 0; i < this.GameViewModel.Fields.Count; i++)
                {
                    this.GameViewModel.Model.Fields[i, selectedField.Column].Owner = 0;
                }
                for (int i = 0; i < this.GameViewModel.Fields.Count; i++)
                {
                    this.GameViewModel.Model.Fields[selectedField.Row, i].Owner = 0;
                }
                return true;
            }
            return false;
        }
    }
}
