namespace _02_Dedicnost_03_bankovni_ucty
{
    internal class SporiciUcet : Ucet
    {
        public double UrokovaMira { get; private set; } = 1.35;

        public void Urokuj()
        {
            Stav += Stav * UrokovaMira / 100;
        }
    }
}
