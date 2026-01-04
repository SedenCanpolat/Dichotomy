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

## 🛠️ Key Technical Implementations

### Physics-Based Character Control System

Implemented a dual-character control scheme using Unity’s `HingeJoint2D` and `JointMotor2D`:

- **Individual leg control**  
  Each leg (thigh and calf) operates independently via separate input keys.

- **Motor-driven physics**  
  Joint motors apply torque-based movement for walking and balance.

- **Basic stabilization logic**  
  Angular difference calculations help reduce excessive misalignment when idle.

### Physics-Based Arm Aiming (Joint-Driven)

Developed a proportional control system for a 2D arm aiming using physics joints:

- **Angle-error–based motor control**  
  Arm rotation is driven by the angular difference toward the mouse position.

- **Motor speed clamping**  
  Limits joint rotation speed for stable aiming.

- **Joint limit support**  
  Optional angle clamping when joint limits are enabled.

- **Recoil mechanics**  
  Impulse forces are applied to the player's body during shooting.

- **Physics-driven design**  
  Uses joint motor control instead of inverse kinematics.

### Dialogue System

Built a coroutine-based dialogue system with text animation:

- **Character-by-character rendering**  
  Typewriter-style text output.

- **Adjustable text speed**  
  Text speed is configurable.

- **UI animations**  
  Dialogue box open and close transitions using scaling.

- **Actor-message mapping**  
  Supports multiple actors per dialogue sequence.

### NavMesh Enemy AI

Utilized Unity’s `NavMeshAgent` system for enemy movement:

- **Distance-based activation**  
  Enemies pursue or react only within a defined detection range.

- **2D NavMesh configuration**  
  Rotation and up-axis updates are disabled for 2D compatibility.

- **Proximity-triggered behaviors**  
  Certain enemies explode when reaching a specified range near the player.

