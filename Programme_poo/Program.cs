using System;
using System.Collections.Generic;

namespace Programme_poo
{
    // 1 - Créer une classe Enfant (Etudiant)
    // 2 - Constructeur : nom et l'age ; infoEtudes = null
    // 3 - Main -> Créer un enfant "Sophie", 7 -> Afficher

    // 4 - ClasseEcole "CP"
    // 5 - Afficher Enfant en classe de CP
    // 6 - AfficherProfesseurPrincipal
    class Enfant : Etudiant
    {
        string classEcole;
        Dictionary<string, float> notes;
        public Enfant(string nom, int age, string classEcole, Dictionary<string, float> notes) : base (nom, age, null)
        {
            this.classEcole = classEcole;
            this.notes = notes;
        }

        public override void Afficher()
        {
            AfficherNonAge();
            Console.WriteLine(" Enfant en classe de " + classEcole);
            if((notes != null)&&(notes.Count > 0))
            {
                Console.WriteLine(" Notes moyennes :");
                foreach (var note in notes)
                {
                    Console.WriteLine("   " + note.Key + " : " + note.Value + " / 10");
                }
            }
            AffficherProfesseurPrincipal();
        } 
    }

    // Maths : 5 / 10
    // Geo : 8,5 / 10
    // clef : string / valeur : float
    // Dictionary<string, float>
    // Dictionary<string, float> {{"Maths, 5f}, {"Geo", 8.5f}}

    class Etudiant : Personne
    {
        string infoEtudes;
        public Personne professeurPrincipal { get; init; }
        public Etudiant(string nom, int age, string infoEtudes) : base(nom, age)
        {
            this.infoEtudes = infoEtudes;
        }

        public override void Afficher()
        {
            AfficherNonAge();
            Console.WriteLine(" Etudiant en " + infoEtudes);
            AffficherProfesseurPrincipal();

        }

        protected void AffficherProfesseurPrincipal()
        {
            if (professeurPrincipal != null)
            {
                //Le professeur principal est :
                Console.WriteLine("Le professeur principal est : ");
                // afficher les informations
                professeurPrincipal.Afficher();
            }
        }
    }

    class TableDeMultiplication : IAffichable
    {
        int numero;

        public TableDeMultiplication(int numero)
        {
            this.numero = numero;
        }

        public void Afficher()
        {
            Console.WriteLine("Table de multiplication " + numero);
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i + " x " + numero + " = " + (i * numero));
            }
        }
    }

    class Personne : IAffichable
    {
        private static int nombreDePersonnes = 0;

        //public string nom { get; init; }
        protected string nom;
        //public int age { get; init; }

        protected int age;
        //public string emploi { get; init; }

        protected string emploi;
        
        protected int numeroPersonne;

        /*public string GetNom()
        {
            return nom;
        }

        public void SetNom(string value)
        {
            nom = value;
        }*/
        public Personne()
        {
            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;
        }

        public Personne(string nom, int age, string emploi = null) : this()
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;           
        }

        /*public Personne(string nom, int age) : (nom, age, "non spécifié")
        {

        }*/

        public virtual void Afficher()
        {
            AfficherNonAge();
            if(emploi == null)
            {
                Console.WriteLine(" Emploi non spécifié");
            }
            else
            {
                Console.WriteLine(" EMPLOI : " + emploi);
            }
        }

        protected void AfficherNonAge()
        {
            Console.WriteLine("PERSONNE N°" + numeroPersonne);
            Console.WriteLine(" NOM : " + nom);
            Console.WriteLine(" AGE : " + age + " ans");
        }

        public static void afficherNombreDePersonne()
        {
            Console.WriteLine("Nombre total de personnes : " + nombreDePersonnes);
        }
    }

    interface IAffichable
    {
        void Afficher();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var elements = new List<IAffichable> { new Personne("Ellie", 20, "Développeuse"),
                                                   new Personne("Joel", 45, "Professeur"),
                                                   new Personne("Nathan", 20, "Etudiant"),
                                                   new Personne ("Juliette", 8, "CP"),
                                                   new TableDeMultiplication(2)};
            
            foreach(var element in elements)
            {
                element.Afficher();
            }

            Personne.afficherNombreDePersonne();

            //var professeur = new Personne("Jacques", 35, "Professeur");

            var etudiant = new Etudiant("David", 20, "école d'ingénieur informatique") { 
                professeurPrincipal = new Personne("Jacques", 35, "Professeur")};
            etudiant.Afficher();

            var notesEnfant1 = new Dictionary<string, float> {{"Maths", 5f}, {"Geo", 8.5f}};

            var enfant = new Enfant("Sophie", 7, "CP", notesEnfant1)
                {
                professeurPrincipal = new Personne("John", 45, "Professeur")};
            enfant.Afficher();

            var table2 = new TableDeMultiplication(2);
            table2.Afficher();
        }
    }
}
