# Dichotomy

**Dichotomy** is a 2D action game developed using Unity for **Magara Jam ’25**, created within **72 hours**.

Dichotomy was ranked in the **Top 15–50** out of **400+ contributors**.  
*(Note: There is no exact ranking within the 15–50 bracket.)*

In the game, players control two characters who are struggling after being kidnapped by an evil scientist and turned into conjoined twins. Together, they must fight for their freedom.

🎮 **Play From Here**: [https://seden.itch.io/dichotomy](https://seden.itch.io/dichotomy)

**Seden Canpolat:** I worked as a developer, handling the coding, story, and level design.  

In terms of coding, I worked on:
- Scene management, transitions, and dialogue system  
- Enemy AI behaviors

![MagaraJam252025-10-0514-20-51-ezgif com-optimize](https://github.com/user-attachments/assets/aae10454-a81a-4523-9b88-3ff440d8d24b)

## Key Technical Implementations

### Physics-Based Character Control System

Implemented a dual-character control scheme using Unity’s `HingeJoint2D` and `JointMotor2D`:

- **Individual leg control**  
  Each leg (thigh and calf) operates independently via separate input keys.

- **Motor-driven physics**  
  Proportional motor control maintains body balance while allowing dynamic movement.

- **Adaptive stabilization**  
  Angular difference calculations automatically stabilize the body during motion.

### Physics-Based Arm Aiming (Joint-Driven)

Developed a proportional control system for a realistic 2D arm aiming using physics joints:

- **Angle-error–based motor control**  
  Arm rotation is driven by the angular difference toward the mouse position.

- **Motor speed clamping**  
  Ensures stable and responsive joint movement (up to 360°/s).

- **Joint limit support**  
  Optional constraints for controlled arm rotation.

- **Recoil mechanics**  
  Impulse forces are applied during shooting to provide physical feedback.

- **Physics-driven design**  
  Uses joint motor control instead of inverse kinematics.

### Typewriter Dialogue System

Built a coroutine-based dialogue manager with smooth text animations:

- **Character-by-character rendering**  
  Adjustable text speed for a typewriter effect.

- **Skip functionality**  
  Click to instantly complete the current message or advance to the next.

- **UI animations**  
  Smooth scale-based dialogue box open and close transitions using `Lerp`.

- **Actor-message mapping**  
  Flexible system supporting multiple speakers per conversation.

- **State management**  
  Proper coroutine cleanup to prevent memory leaks.

### NavMesh Enemy AI

Utilized Unity’s NavMesh system for intelligent enemy pathfinding:

- **Distance-based activation**  
  Enemies pursue the player only within detection range to optimize performance.

- **2D NavMesh configuration**  
  Proper setup for 2D physics with rotation and up-axis updates disabled.

- **Proximity-triggered behaviors**  
  Explosion mechanics activate when enemies reach a specified range.

- **Dynamic destination updates**  
  Continuous path recalculation ensures responsive enemy movement.

