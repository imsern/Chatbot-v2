namespace Chatbot_v2;
using System;

public class Bot
{
    public string firstName { get; set; }
    public string lastName { get; set; }

    public string[] keywords =
    {
        "internett", "telefon", "kundeservice", "vet", "ikke", "privat", "bedrift",
        "bredbånd" ,"fiber", "tregt", "4G", "mistet", "har", "abonnement", "dekning",
        "gigabyte", "gb", "endre", "bestille", "kansellere"
    };
    public List<string> keywordsUsed = new List<string>();
    

    public Bot(string name)
    {
        var heltNavn = name.Split(' ');
        firstName = heltNavn[0];
        lastName = heltNavn[1];
    }
    private void FindAndAddKeywords(string? problemstilling)
    {
        var probLowerCase = problemstilling.ToLower();
        foreach (var keyword in keywords)
        {
            if (problemstilling != null && probLowerCase.Contains(keyword))
            {
                keywordsUsed.Add(keyword);
            }
        }
    }

    public void Problem(string? problemstilling)
    {
        FindAndAddKeywords(problemstilling);
        
        problemCheck();
        var answer = Console.ReadLine();
        StepTwo(answer);
        answer = Console.ReadLine();
        StepThree(answer);

    }

    private void problemCheck()
    {
        if (keywordsUsed.Contains("kundeservice") ||
            keywordsUsed.Contains("vet") &&
            keywordsUsed.Contains("ikke"))
        {
            StepOne("kundeservice");
        }
        else if (keywordsUsed.Contains("internett") &&
                 keywordsUsed.Contains("telefon"))
        {
            StepOne("4G");
        }
        else if (keywordsUsed.Contains("internett"))
        {
            StepOne("internett");
        }
        else if (keywordsUsed.Contains("telefon"))
        {
            StepOne("telefon");
        }
        else StepOne();
    }

    private void StepOne(string problem = "ukjent")
    {
        keywordsUsed.Clear();
        switch (problem)
        {
            case "4G":
                Console.WriteLine("4G biten kommer her(dette gjelder privat kunder)");
                break;
            case "internett":
                Console.WriteLine("Gjelder det mobilt bredbånd eller gjelder det fiber?");
                break;
            case "telefon":
                Console.WriteLine("Gjelder det Privat kunde eller bedrift?");
                break;
            case "kundeservice":
                Console.WriteLine("Hvis du er usikker eller du heller vil snakke med oss på telefon, kan du ringe +47 91 62 30 33");
                break;
            default:
                Console.WriteLine(
                    "Beklager, men jeg har ikke helt forstått hva du mente. " +
                    "\nSkriv: internett eller telefon etter hva du har behov for hjelp til! Om du ønsker å snakke med oss på telefon kan du skrive: kundeservice"
                );
                break;
        }
    }

    private void StepTwo(string? answer = "ukjent")
    {
        FindAndAddKeywords(answer);
        if (keywordsUsed.Contains("fiber"))
        {
            Console.WriteLine("Gjelder det tregt/mistet nett eller ønsker du bestille fiber hos oss?");
            keywordsUsed.Clear();
        }
        else if (keywordsUsed.Contains("bredbånd"))
        {
            Console.WriteLine("Gjelder det tregt/mistet nett eller ønsker du bestille mobilt bredbånd hos oss?");
            keywordsUsed.Clear();
        }
        else Console.WriteLine("Beklager, men jeg har ikke helt forstått hva du mente.");
        keywordsUsed.Clear();
    }

    private void StepThree(string? answer = "ukjent")
    {
        FindAndAddKeywords(answer);
        if (keywordsUsed.Contains("mistet") || keywordsUsed.Contains("tregt"))
        {
            internettSolution1();
        }
        else if (keywordsUsed.Contains("bestille"))
        {
            orderNewService();
        }
        else Console.WriteLine("Beklager, men jeg har ikke helt forstått hva du mente.");
        keywordsUsed.Clear();
    }

    private void internettSolution1()
    {
        Console.WriteLine("Insert problem solution here");
    }

    private void orderNewService()
    {
        Console.WriteLine("Insert link to order some sort of service here");
    }

}

/*
 * keywords = internett - telefon - kundeservice
 * internett -> mobilt bredbånd / fiber
 *      -> mistet internett // tregt internett
 *         -> løsningsforslag 1 -> funker/funker ikke?
 *              -> Hvis ikke -> løsningsforslag 2 -> funker/funker ikke?
 *              -> Hvis ikke -> anbefales å ringe kundeservice
 *              -> Hvis det funker -> Avskjedsbeskjed + evt kundeanmeldelse
 * telefon -> privat / bedrift
 *      -> Privat -> Skade på mobil // 4G problemer // Abonnoment
 *         -> Skade på mobil
 *              -> Forsikring?
 *         -> 4G problemer
 *              -> Tregt
 *              -> Dekning
 *              -> Gigabyte
 *         -> Abonnement
 *              -> Endre
 *              -> Stifte
 *              -> Kansellere
 * 
 * Hvis dette var feil eller ingen alternativ passer - skriv kundeservice
 *
 *
 *
 * Fikk du hjelp til det du lurte på?
 *
 * bør legges til at den sjekker for hver char i keywords tilfelle en skrivefeil som i f.eks internett (internet)
 * toCharArray()
 * */