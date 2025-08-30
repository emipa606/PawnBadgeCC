# Copilot Instructions for Pawn Badge - Collection

## Mod Overview and Purpose

**Pawn Badge - Collection** is a comprehensive RimWorld mod that combines various badge-themed mods into a single, unified mod. This allows players to choose active badge sets through the mod options within the game. The intent is to streamline badge management and enhance customization. The mod invites users to propose ideas for new badge sets, thereby encouraging community involvement and continuous expansion.

## Key Features and Systems

- **Unified Badge Management:** Combines multiple badge mods into a single entity for easier setup and execution.
- **Selectable Badge Sets:** Offers a configurable system through mod options where users can enable or disable different badge sets based on their preferences.
- **Variety of Themes:** Includes badges from popular thematic sets such as Star Wars, Command and Conquer, and WWII, catering to diverse interests.
- **Transparency Options:** Includes more transparent versions of certain badges, enhancing visual customizability thanks to community contributions.
  
### Included Badge Themes

- **Star-Wars Themed:**
  - Imperial Army
  - Imperial Navy
  - Rebels

- **Texas Redhawks Mods:**
  - Command and Conquer Brotherhood of Nod
  - Command and Conquer Global Defense Initiative
  - WWII German Army

## Coding Patterns and Conventions

- **C# Conventions:** The mod follows standard C# conventions for naming, formatting, and structuring the code. This includes using PascalCase for class and method names, and camelCase for local variables.
- **Mod Structure:** The mod uses internal classes for main functionality encapsulation, ensuring that only relevant parts of the codebase are exposed when necessary.

## XML Integration

- **Mod Options Integration:** XML is used for configuring mod options, ensuring that badge visibility and other user preferences are easily manageable through the game's interface.
- **Localization Support:** XML files should be used to manage in-game text for easy translation and localization support.

## Harmony Patching

- **Introduction to Harmony:** Harmony is used for patching RimWorld's original methods. Although specific methods to patch are not provided in the information, contributors can use Harmony to extend, replace or add functionality where needed.
- **Guidelines for Patch Development:** Ensure that patches are non-destructive and include error handling to prevent breaking the base game functionalities.

## Suggestions for Copilot

- **Consistent API Usage:** Leverage Copilot to suggest consistent API patterns across new code contributions, especially for common tasks such as list management and UI handling.
- **Badge Addition Facilitation:** Use Copilot to streamline the addition of new badge sets by suggesting patterns in XML integration and C# method structures.
- **Code Refactoring:** Utilize Copilot’s capability to refactor existing methods, enhancing code efficiency and readability.
- **Documentation and Comments:** Encourage using Copilot to generate comments and documentation within the codebase to assist new contributors in understanding existing functionality.
