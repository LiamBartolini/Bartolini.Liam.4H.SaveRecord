using System.IO;
using System.Collections.Generic;

namespace Bartolini.Liam._4H.SaveRecord.Models
{
    public class Comune
    {
        public int ID { get; set; }
        public string NomeComune { get; set; }
        public string CodiceCatastale { get; set; }
    
        public Comune() { }

        public Comune(string riga, int id)
        {
            string[] colonne = riga.Split(',');
            ID = id;
            CodiceCatastale = colonne[0];
            NomeComune = colonne[1];
        }
    }

    public class Comuni : List<Comune> // Comuni è una List<Comuni>
    {
        public string NomeFile { get; }

        public Comuni() { }

        public Comuni(string fileName) 
        {
            NomeFile = fileName;

            using (FileStream fin = new FileStream(fileName, FileMode.Open))
            {
                StreamReader reader = new StreamReader(fin);
                
                int id = 1;
                
                while (!reader.EndOfStream)
                {
                    string riga = reader.ReadLine();
                    Comune c = new Comune(riga, id++);
                    Add( c );
                }
            }
        }

        public void Save()
        {
            string fileName = NomeFile.Split('.')[0] + ".bin";
            Save( fileName );
        }

        public void Save(string fileName)
        {
            FileStream fout = new FileStream(fileName, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fout);
            
            foreach (Comune comune in this)
            {
                writer.Write(comune.ID);
                writer.Write(comune.CodiceCatastale);
                writer.Write(comune.NomeComune);
            }

            writer.Flush();
            writer.Close();
        }

        public void Load()
        {
            string fn = NomeFile.Split('.')[0] + ".bin";    
            Load( fn );        
        }

        public void Load(string fileName)
        {
            Clear(); // cancella tutti i record

            FileStream fin = new FileStream(fileName, FileMode.Open);
            BinaryReader reader = new BinaryReader(fin);

            Comune c = new Comune();

            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {   
                // Leggo l'ID
                c.ID = reader.ReadInt32();

                // Leggo il codice catastale
                c.CodiceCatastale = reader.ReadString();

                // Leggo il nome del comune
                c.NomeComune = reader.ReadString();

                Add( c );
            }
        }
    }
}