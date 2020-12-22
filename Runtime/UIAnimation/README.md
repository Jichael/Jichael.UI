Ce système permet l'animation d'éléments d'interface (UI).

Les animations possibles sont les suivantes :

 - Translation
  -- TranslationCurve : courbe qui définie le comportement de l'animation
  -- TranslationDuration : durée en seconde de la translation
  -- TranslationOffset : décalage de départ de la translation
 
 - Rotation
  -- RotationCurve : courbe qui définie le comportement de l'animation
  -- RotationDuration : durée en seconde de la rotation
  -- RotationMaxAngle : angle maximal de la rotation
 
 - Scaling
  -- ScalingCurve : courbe qui définie le comportement de l'animation
  -- ScalingDuration : durée en seconde du scaling
  -- ScalingMultiplier : multiplicateur de valeur de la courbe
  
 - Fade
  -- FadeCurve : courbe qui définie le comportement de l'animation
  -- FadeDuration : durée en seconde du fade
  
 
Ces animations peuvent être combinées pour obtenir le rendu souhaité.

On peut créer des presets d'animation via le ScriptableObject UIAnimationEffectPreset, qui peuvent ensuite être chargés sur un controller.

Le script UIAnimationManager gère les animations.

Le script UIAnimationController est utilisé pour rendre un élément d'interface animable :

 - On peut définir X effets d'animation dans le tableau AnimationEffects
 - Pour les effets Translation/Rotation/Scaling, on doit utiliser la RectTransform de l'objet
 - Pour l'effet Fade, on doit utiliser un CanvasGroup sur l'objet
 - On peut définir le comportement de l'objet par "AnimateOn" :
  -- None : aucune animation automatique
  -- Start : la première fois que l'objet devient actif, déclenche l'animation à l'index 0 du tableau
  -- Enable : à chaque fois que l'objet devient actif, déclenche l'animation à l'index 0 du tableau
 - On peut charger un preset d'effet dans le tableau en renseignant l'index "IndexLoadPreview", en selectionnant un preset et en cliquant sur "Load",
 le tableau doit avoir la taille nécessaire pour acceuillir le nouvel effet à charger. On peut ensuite modifier l'effet sur le controller.
 - On peut jouer un effet directement en EditMode en renseignant l'index "IndexLoadPreview", puis en cliquant sur "PreviewAnimation". L'index doit être un élément valide du tableau.
 
