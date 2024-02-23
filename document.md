Ces 3 api sont fonctionnelles :

REST Countries (https://restcountries.com/v3/)
Exemple : https://restcountries.com/v3/name/france
    > Visiter l'adresse si dessus fournit bien des informations sur la France, le resultat se trouve dans le fichier country.json

PokeAPI (https://pokeapi.co/api/v2/)
Exemple : https://pokeapi.co/api/v2/pokemon/bulbasaur
    > Visiter l'adresse si dessus fournit bien des informations sur Bulbasaur, le resultat se trouve dans le fichier pokemon.json

API LNCrawler (api.lncrawler.monster)
Exemple : https://api.lncrawler.monster/novels?page=0&number=2
    > Visiter l'adresse si dessus fournit bien des informations sur les 2 premiers romans (page 0 si chaque page contient 2 romans), le resultat se trouve dans le fichier novels.json
Exemple 2 : https://api.lncrawler.monster/novel?novel=reverend+insanity&source=mixednovel-net
    > Visiter l'adresse si dessus fournit bien des informations sur le roman "Reverend Insanity" provenant de la source "mixednovel-net", le resultat se trouve dans le fichier novelFromSource.json
Exemple 3 : https://api.lncrawler.monster/chapter/?novel=reverend+insanity&source=mixednovel-net&chapter=1
    > Visiter l'adresse si dessus fournit bien des informations sur le premier chapitre du roman "Reverend Insanity" provenant de la source "mixednovel-net", le resultat se trouve dans le fichier chapter.json

Votre interface doit respecter les contraintes minimales suivantes :
o	Avoir un minimum de 10 champs (propriétés)
    > author, chapter_count, clicks, comment_count, cover, current_week_clicks, language, latest, overall_rating, title ...
o	Avoir et/ou utiliser un minimum de 4 classes différentes pour votre modèle
    > Novel, NovelFromSource, Metadata, Chapter, NovelWrapper, ChapterWrapper ...
o	L’interface doit contenir minimalement une liste déroulante (drop down)
    > Choix de langue de l'application
o	L’interface doit contenir minimalement un bouton radio qui sera utilisé pour effectuer un changement quelconque dans l’affichage
    > Choix du thème de l'application
o	Afficher minimalement 1 image qui est contextuelle à une sélection ailleurs dans l’interface. Le changement de l’image doit être effectué dans les instants après la modification d’un élément de votre choix (pas nécessairement instantanément, mais doit être fait automatiquement en fonction d’un évènement ciblé)
    > La couverture du roman, changer la page du menu change l'image
o	Intégrer la gestion multilingue d’au moins 2 langues à l’aide de ressources. Votre interface devra donc prendre en compte la langue sélectionnée afin d’afficher en conséquence les bons étiquettes (label)
    > Le bouton radio change la langue des labels à l'aide de fichiers de ressources
o	Vous devez ajouter un élément « nouveau » que vous trouvez intéressant d’explorer dans votre programme qui à un aspect visuel quelconque. Un composant, un élément graphique, une particularisation d’un style de x,y,z, etc.
    > Un ScrollViewer pour le chapitre, différent thèmes à l'aide de fichier ressources, une Frame de navigation ...
