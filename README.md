# Studentenadministratie
Voor deze oefening werk je verder op een bestaand project. Gegeven is een
applicatie die gebruikt kan worden om studenten in op te slaan. Dit project is
zo opgezet dat er een duidelijke scheiding te vinden is tussen de verschillende
lagen van de applicatie. Ook al is het nog een klein project, de voordelen van
deze opzet zijn toch al duidelijk. Zo kunnen we bijvoorbeeld onze applicatie
goed voorzien van unit tests en hebben we een duidelijke plek voor onze domein
en business logica.

De opzet die gebruikt is noemen we het *repository pattern*. De gedachte
hierachter is dat de view-laag (je Form) met een repository klasse communiceert
als er gegevens opgehaald of opgeslagen moeten worden. Dit is de logica-laag.
Deze gebruikt vervolgens een context om de feitelijke persistentie te laten
regelen: de data-laag. Doordat de data-laag vastgelegd staat in een interface,
kunnen we eenvoudig meerdere vormen van opslag aanbieden: een SQLite
implementatie kan bestaan naast een file based persistentie; voor onze unit
tests gebruiken we een in-memory opslag.

De applicatie is echter nog niet helemaal af. Er is al een begin gemaakt met de
functionaliteit die het toekennen van cijfers aan studenten mogelijk moet
maken, maar het is aan jou om dit in lijn met de gegeven code uiteindelijk te
realiseren. De docent wil namelijk de resultaten voor de individuele opdracht
van SE2 met deze tool gaan administreren.

Tip: mocht je tijdens het doorlopen van deze oefening het spoor bijster raken,
kijk dan naar de bestaande implementatie van de `Student*` klassen. Deze is
vergelijkbaar met wat benodigd is voor de `Grade*` klassen.

## De Grade klasse
Als eerste moet de `Grade` klasse geïmplementeerd worden. Deze is nu nog leeg:
zorg ervoor dat onderstaande punten beschikbaar zijn:

 1. De klasse krijgt 3 properties: `Analysis`, `Design` en `Code`. Alle
    properties zijn van het type `decimal` en readonly.
 1. Indien de constructor die de attributen van de klasse instelt een ongeldige
    invoer krijgt (een van de cijfers is kleiner dan 0 of groter dan 10), dan
    gooit deze een `InvalidGradeException` op. Implementeer deze nieuwe
    exception en de gevraagde logica.
 1. Er is al een bestand beschikbaar gemaakt om de `Grade` klasse te testen.
    Implementeer in het `GradeTest.cs` bestand een eerste unittest die de
    aangemaakte constructor *volledig* test.

## De repositories implementeren
Nu we een model gemaakt hebben om onze gegevens in op te slaan, zorgen we
ervoor dat deze met de database kan werken. Maak een nieuw bestand aan genaamd
`GradeSQLiteContext`. We gaan dit bestand vullen op dezelfde manier zoals het
`StudentSQLiteContext` bestand.

 1. Maak een methode `GetForStudent` aan, en implementeer deze. Zorg dat deze
    functie overeenkomt met de in de `IGradeContext` interface gevonden
    functie, zodat de `GradeRepository` hiermee kan werkt. *Merk op dat de
    klasse zelf dus niet deze interface dient te implementeren.* Zie het
    `Database.cs` bestand voor informatie over de opzet van de `Grade` tabel.
 1. Doe hetzelfde voor de `Insert` methode: voeg ook deze to aan de
    `GradeSQLiteContext` klasse.
 1. Maak in het formulier een nieuwe `GradeRepository` aan, vergelijkbaar met
    hoe de `StudentRepository` gemaakt wordt. Als alles goed is geïmplementeerd
    zou dit moeten compileren zonder fouten.
 1. Werk nu ook je unit tests bij. Hiervoor is al een in-memory context
    beschikbaar, maar de tests ontbreken nog. Realiseer een unit test die het
    toevoegen en ophalen van grades *volledig* test.

## Business logica en afronding
Als laatste stap voegen we nog wat business logica toe. Eerder hebben we al
gezorgd dat de `Grade` klasse geen ongeldige cijfers kan bevatten. Voor de
individuele opdracht van SE2 zit er echter een weging tussen de cijfers, alsook
een voorwaarde voor het bepalen van het eindcijfer. Deze business logica moet
terecht komen in onze logica-laag; in de repository dus.

 1. De eerste voorwaarde is dat alle deelcijfers voldoende dienen te zijn. Voeg
    hiervoor een methode en implementatie toe aan de `GradeRepository` klasse
    welke, gegeven een `Grade` instantie, bepaald of hieraan voldaan is.
 1. Ook het berekenen van het gemiddelde dient in de genoemde klasse terecht te
    komen. Gegeven een `Grade` instantie bepaald deze functie het gemiddelde
    van de drie deelcijfer, waarbij de analyse voor 20%, het ontwerp voor 30%
    en de code voor 50% het eindcijfer bepaald. Dit cijfer moet afgerond worden
    naar een geheel getal. Is een van de deelcijfers onvoldoende, dan wordt het
    gemiddelde gelijk aan de laagste onvoldoende.
 1. Implementeer twee nieuwe unit tests die deze functies *volledig* testen.
 1. Tot slot: zorg ervoor dat de GUI werkt. Als het goed is, en je unit tests
    correct zijn opgezet, is dit slechts een formaliteit.

