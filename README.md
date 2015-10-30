# SE2 Game

Deze week worden pickups toegevoegd aan de game, evenals het opslaan en laden
van de maps. In de uitwerking op GitLab zit dit al voor een deel gewerkt, maar
het is natuurlijk ook prima om dit op je eigen manier aan je eigen
implementatie toe te voegen.

## De opdracht voor deze week

 1. Om duidelijk te krijgen hoe items werken in het spel, mogen er nog twee
    toegevoegd worden. Voor nu is alleen een sleutel benodigd, maar we willen
    ook een item hebben wat de player beïnvloed. Maak hiervoor een nieuwe
    `Item` aan wat een soort helm is: als de player deze helm in zijn bezit
    heeft, ontvangt hij maar de helft van de damage die normaal ontvangen
    wordt. Merk op dat er al afbeeldingen in de Sprites map staan voor de
    nieuwe items; ook kun je zelf een nieuwe sprite op internet zoeken.
 1. Ook willen we een soort laarzen als item: zijn deze opgepakt, dan
    zal de player 50% sneller kunnen lopen.
 1. Beide items zijn verplicht om te hebben voordat het spel gewonnen kan
    worden. Pas hiervoor de code aan zodat dit naar behoren werkt.
 1. De applicatie genereert nu bij het opstarten een willekeurige map. Het
    makkelijkste begin maken we door eerst deze map op te slaan bij het
    opstarten van de applicatie. Zorg ervoor dat dit gebeurd door aan het einde
    van de constructor van de `Map` klasse, de gegenereerde map op te slaan.
    Sla voor nu de gegevens op in een tekstbestand met als naam
    "latest_generated_map.txt", zodanig dat je later dit bestand kunt aanpassen
    met een teksteditor.
 1. Probeer nu het opgeslagen bestand weer in te lezen bij het opstarten van de
    applicatie. Om dit te testen laad je het bestand in, wederom in de
    constructor van de `Map` klasse. Als het alles correct geïmplementeerd is
    zou je bij het opstarten iedere keer dezelfde map moeten zien. Door nu zelf
    het opgeslagen bestand te bewerken zou je zelf een level moeten kunnen
    inrichten.
 1. Het kan natuurlijk gebeuren dat bij het bewerken van een level een fout
    gemaakt wordt. We willen hier op een subtiele manier mee om gaan, dus
    zullen we de foutafhandeling realiseren met exceptions. Maak zelf een
    nieuwe `InvalidMapException` klasse aan, en zorg dat deze opgegooid wordt
    als er een probleem is bij het inladen van een level. In het formulier
    "catch" je deze exception vervolgens en toon je een melding aan de
    gebruiker.
 1. Nu we levels kunnen maken, is het ook wel makkelijk om levels te kunnen
    kiezen voordat we het spel beginnen. Voeg hiervoor controls toe op het
    formulier, en gebruik de `OpenFileDialog` klasse om de gebruiker een
    bestand te laten kiezen wat als level gebruikt moet worden.
 1. Heb je dit alles af? Prima! Lever de opdracht in op Canvas. Mocht je nog
    behoefte hebben aan een verdere uitdaging, probeer dan eens of je het spel
    kunt opslaan als het formulier wordt afgesloten door een aantal klassen te
    voorzien van het `DataContract` attribuut. Ook kun je mogelijk nog wat
    nieuwe pickups verzinnen zoals bijvoorbeeld een deur die zorgt dat de
    speler naar een willekeurige andere deur teleporteert.

