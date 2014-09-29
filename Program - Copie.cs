using System;

namespace ITI.Light
{
    class Program
    {
        static void Main(string[] args)
        {
            Lamp l1 = new Lamp();
            Lamp l2 = new Lamp();
            Lamp l3 = new Lamp();
            Lamp l4 = new Lamp();

            Switch s = new Switch(5);
            s.Close();
            s.Open();
            s.AssignLamp(l1);
            s.AssignLamp(l2);
            s.Close();
            s.Open();
            s.Close();
            s.AssignLamp(l3);
            s.UnassignLamp(l2);
            s.AssignLamp(l4);

            // Je peux assigner autant de fois que je veux la même lampe, faut-il le corriger ?
           /* s.AssignLamp(l4);
            s.AssignLamp(l4);
            s.AssignLamp(l4);
            */
            #region Bloc de test à déplacer pour les tests
            int j = 0;
            foreach (Lamp i in s.Lamps)
            {
                j++;
                if ( i != null)
                Console.WriteLine(j + " : " + i.IsOn);
            }
            #endregion

            Console.ReadLine();
        }
    }
}
