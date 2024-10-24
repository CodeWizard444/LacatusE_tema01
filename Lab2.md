1) Viewport-ul reprezintq zona de pe fereastra in care sunt desenate obiectele 3D.
2) FPS reprezinta numarul de imagini complete care sunt randate si afisate pe ecran intr-o secunda.
3) Metoda OnUpdateFrame() este rulata inainte de fiecare cadru randat.
4) Modul imediat de randare este o tehnica din versiunile vechi de OpenGL in care fiecare punct, linie sau poligon este trimis direct catre GPU in momentul in care este specificat.
5) Modul imediat a fost depreciat incepând cu OpenGL 3.0 si complet eliminat din nucleul standard al OpenGL in OpenGL 3.1.
6) Metoda OnRenderFrame() este rulata pentru fiecare cadru care trebuie randat pe ecran.
7) Metoda OnResize() este necesara pentru a ajusta dimensiunile viewport-ului si proiectia perspectivei la dimensiunile curente ale ferestrei.
8) Metoda CreatePerspectiveFieldOfView() din OpenTK creează o matrice de proiectie pentru a defini perspectiva camerei.
   Parametrii principali sunt: -Field of View
                               -Aspect Ratio
                               -Near Clip Plane
                               -Far Clip Plane
