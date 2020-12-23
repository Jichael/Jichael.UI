Ce système a été mis en place pour générer automatiquement des interfaces utilisateurs (UI) via le package StateMachine.

Il est composé de :

 - Un script UIGeneration qui va gérer la génération des interfaces.
 - Deux types d'UI peuvent être générées : une "action texte" (GuideText) et une "question" (GuideQuestion)
  -- Les scripts UIGuideTextTemplate et UIGuideAnswerTemplate sont mis sur les prefabs qui vont être instantiés.
 - Le script UIGuideQuestion sur l'UI de question.
 - Les ScriptablesObjects GuideQuestion/GuideText qui permettent de créer directement dans le projet les "valeurs" des UI.
 
Pour lier la génération d'UI à un scénario (StateMachine) :

 - Sur un état, rajouter le script UIGuideQuestionHolder/UIGuideTextHolder
 - On lie le ScriptableObject sur ce script.
 - Deux méthodes sont disponibles : CreateUI et SetDone qui permettent respectivement de créer/terminer l'UI correspondante.
 - Ces méthodes peuvent être placées directement dans les évenements d'état et de transition pour gérer l'apparition/disparition des UI.