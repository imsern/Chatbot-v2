using System;
using System.Diagnostics.Tracing;
using Chatbot_v2;

Console.WriteLine("Skriv inn fornavn og etternavn");
var fulltNavn = Console.ReadLine();
var chatbot = new Bot(fulltNavn);
Console.WriteLine($"Hei {chatbot.firstName} {chatbot.lastName}! Hva kan vi hjelpe deg med?");

    var problemstilling = Console.ReadLine();
    chatbot.Problem(problemstilling);
