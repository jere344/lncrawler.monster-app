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

Les requis pour l'API sont donc les suivants :
- 10 champs (propriétés)
- 4 classes différentes pour le modèle
- Une liste déroulante (drop down)
- Un bouton radio
- 1 image contextuelle
  
L'API contient bien :
- 10 champs (propriétés) : author, chapter_count, clicks, comment_count, cover, current_week_clicks, language, latest, overall_rating, title ...
- 4 classes différentes pour le modèle : Novel, NovelFromSource, Metadata, Chapter ...
- Une liste déroulante (drop down) : liste de tag pour la recherche
- 1 image contextuelle : la couverture du roman
