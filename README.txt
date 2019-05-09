Resources
---------------------------------------
https://answers.unity.com/questions/570573/how-do-i-slowly-translate-a-object-to-a-other-obje.html - Vector3.MoveTowards() found here, used in KeyCardScanner.cs

https://answers.unity.com/questions/1476208/string-format-to-show-float-as-time.html - used for displaying time, used in Timer.cs

Oculus SDK - in Assets/Oculus/



---------------------------------------
Code written by Kyle
---------------------------------------
All code written by Kyle can be found in /Assets/Scripts/
    - Excluding:
        - CameraController.cs
        - PlayerMovement.cs
        - SetCorrectCameraHeight.cs
        ** I'm not sure where these came from or if they have been used so I'm afraid to delete them

    - Code in /Assets/Oculus/SampleFramework/Core/CustomHands/Scripts/Hand.cs tagged with "// new code here" is also written by me.
    - Code in /Assets/Oculus/VR/Scripts/Util/OVRPlayerController.cs altered to include playerCanMove and added all code in FixedUpdate()




---------------------------------------
Division of Labor
---------------------------------------
Alex: Ship Design, Lab equipment design, Escape Pod Design, some Unity brain-storming when Kyle ran into issues
Brett: Alien language design, props for translations, everything with text
Dhahran: All other props in the ship not mentioned above, Suburb scene's props, Alien design, retrieved sound effects, created ambient sounds in ship using a combination of sounds
Kyle: All programming, getting everything integrated into Unity took up most of my time

All: worked on the general idea equally, progression from beginning of the game to the end




---------------------------------------
Known Issues
---------------------------------------
- Extra footstep when player stops moving
- Alien goes through the floor a little bit




---------------------------------------
Submission-Related Grade Areas
---------------------------------------
manual
    - Oculus Rift & Touch controllers required

    -            movement   :   left analog stick
    -              sprint   :   index finger trigger (left controller)
    -                grab   :   middle finger trigger (on either controller)
    - flashlight on / off   :   A/B button (right controller)

    - most interactions in this game require grabbing and placing objects where they would logically go
    - the flashlight can be used as a translator
        - point the flashlight towards alien language, it translates to English

    - to win:
        - get key card from Flight Deck for Escape Pod #3
            - bring oxygen tank from Laboratory to escape pod #3 oxygen tank chamber
            - place red flat/round crystal (from prison cell #2) in wall of Escape Pod #3
            - enter button sequence into escape pod #3
                - alien language representation of a 3
                - 2, 3, 5, 6, 9

install and run
    - under /Builds/, open EscapeRoom.exe to launch game


GitHub: https://github.com/t0tallyKy1e/EscapeRoom

Google Drive: https://drive.google.com/drive/folders/1cgpNffFhXVTlsmKK8lBCmLK9D86rZ7dA