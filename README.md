# Standard.AI.Data.EntityIntelligence

![EntityIntelligence](https://raw.githubusercontent.com/hassanhabib/Standard.AI.Data.EntityIntelligence/main/ei-gitlogo.png)

[![.NET](https://github.com/hassanhabib/Standard.AI.Data.EntityIntelligence/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hassanhabib/Standard.AI.Data.EntityIntelligence/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/Standard.AI.Data.EntityIntelligence?logo=nuget&color=blue)](https://www.nuget.org/packages/Standard.AI.Data.EntityIntelligence)
![Nuget](https://img.shields.io/nuget/dt/Standard.AI.Data.EntityIntelligence?logo=nuget&label=Downloads&color=blue)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f?style=default)](https://github.com/hassanhabib/The-Standard)
[![The Standard](https://img.shields.io/github/v/release/hassanhabib/The-Standard?filter=v2.10.0&style=default&label=Standard%20Version&color=2ea44f)](https://github.com/hassanhabib/The-Standard)
[![The Standard Community](https://img.shields.io/discord/934130100008538142?style=default&color=%237289da&label=The%20Standard%20Community&logo=Discord)](https://discord.gg/vdPZ7hS52X)



## Introduction
.NET library to convert natural language query into SQL queries and generate results

Standard.AI.Data.EntityIntelligence is a Standard-Compliant .NET library built on top of OpenAI endpoints to enable software engineers to develop AI-Powered solutions in .NET.

## Standard-Compliance
This library was built according to The Standard. The library follows engineering principles, patterns and tooling as recommended by The Standard.

This library is also a community effort which involved many nights of pair-programming, test-driven development and in-depth exploration research and design discussions.

## Standard-Promise
The most important fulfillment aspect in a Standard complaint system is aimed towards contributing to people, its evolution, and principles.
An organization that systematically honors an environment of learning, training, and sharing knowledge is an organization that learns from the past, makes calculated risks for the future, 
and brings everyone within it up to speed on the current state of things as honestly, rapidly, and efficiently as possible. 
 
We believe that everyone has the right to privacy, and will never do anything that could violate that right.
We are committed to writing ethical and responsible software, and will always strive to use our skills, coding, and systems for the good.
We believe that these beliefs will help to ensure that our software(s) are safe and secure and that it will never be used to harm or collect personal data for malicious purposes.
 
The Standard Community as a promise to you is in upholding these values.

## Current State of the Project
[![](https://mermaid.ink/img/pako:eNqtVW1vokAQ_isbGk9NrEFA25CmCYhNTExfDtMv0g8rLO2muHjLeq1p_O83u0BZX3p3uRwkys4zM888s28fRpwnxHCNVusjYghRRoWL1CdCbfFCVqTtovYSF6Td062PmFO8zEjR_nQHaM3pCvPtOM9yLuPOJiP51qGNx5y8i8bLtu1jFz_nCeGN08XYhEfzyygjDRyM5KvBBYlzluxVY5qjwV4KQbigey5pmrZLeCf_4GfXakUszfK3-AVzgb7PIhYxmph9c9EJsMCyN90n13UDH12dn18jiQ0U5PP8lfCuxO5uJxGTsEQthYaE_6QxqWH0DSIHEBnG0OBDtKS0GgZb5bjneUyKgrLnE_6QDJWUA6As0_4mQIZYi0UosGxb0vdo_25NmDd9kupmU78WYPXNTomcFmiBCG96lL8GLQD_UAbIa5Q6i_Bh9rAhfHvHQUMhOBY0Z1WgrM0bz6ePlWStRY5SdGCRNnuxmHPMChyL8EfWD2NO1yLIV1dLfj2jSw4r4lCzDZqhjHvMC8JPy7bl3NUutawGtBrwWH1Zl3O0oupwB-i_XlEOMKsGHbI6wKqALxn79md3y9pO9lg1rWkkRJXB-xZpG37cYrHhOKuzyp6Oc9jLlOkpd-U0O3WCYVWNNpaWUafTGWeUMNHtStXj2XRyO1dEpcKR9IszXBQBSVG5EFBKs8w9u7nxhqbZQyAGmibHjjY-f6OJeHGt9XsPxXL7u2emej4dElzAjud46yIwmhqN2q4liWlemjrJ_vgEyY16_obErygCzxtaGgWkCC7-jxBY4BXJ5cV4MvF1HaDE_ycOq4csjaOcsooGTnqdw9dbcbJXX4swesaK8BWmCVxf6gqKDHU1RYYLn3CEvUYGHN_ghzciD7csNtwUZwXpGZt1ggUJKH7meFVZd78ARmc4CA?type=png)](https://mermaid.live/edit#pako:eNqtVW1vokAQ_isbGk9NrEFA25CmCYhNTExfDtMv0g8rLO2muHjLeq1p_O83u0BZX3p3uRwkys4zM888s28fRpwnxHCNVusjYghRRoWL1CdCbfFCVqTtovYSF6Td062PmFO8zEjR_nQHaM3pCvPtOM9yLuPOJiP51qGNx5y8i8bLtu1jFz_nCeGN08XYhEfzyygjDRyM5KvBBYlzluxVY5qjwV4KQbigey5pmrZLeCf_4GfXakUszfK3-AVzgb7PIhYxmph9c9EJsMCyN90n13UDH12dn18jiQ0U5PP8lfCuxO5uJxGTsEQthYaE_6QxqWH0DSIHEBnG0OBDtKS0GgZb5bjneUyKgrLnE_6QDJWUA6As0_4mQIZYi0UosGxb0vdo_25NmDd9kupmU78WYPXNTomcFmiBCG96lL8GLQD_UAbIa5Q6i_Bh9rAhfHvHQUMhOBY0Z1WgrM0bz6ePlWStRY5SdGCRNnuxmHPMChyL8EfWD2NO1yLIV1dLfj2jSw4r4lCzDZqhjHvMC8JPy7bl3NUutawGtBrwWH1Zl3O0oupwB-i_XlEOMKsGHbI6wKqALxn79md3y9pO9lg1rWkkRJXB-xZpG37cYrHhOKuzyp6Oc9jLlOkpd-U0O3WCYVWNNpaWUafTGWeUMNHtStXj2XRyO1dEpcKR9IszXBQBSVG5EFBKs8w9u7nxhqbZQyAGmibHjjY-f6OJeHGt9XsPxXL7u2emej4dElzAjud46yIwmhqN2q4liWlemjrJ_vgEyY16_obErygCzxtaGgWkCC7-jxBY4BXJ5cV4MvF1HaDE_ycOq4csjaOcsooGTnqdw9dbcbJXX4swesaK8BWmCVxf6gqKDHU1RYYLn3CEvUYGHN_ghzciD7csNtwUZwXpGZt1ggUJKH7meFVZd78ARmc4CA)

<!--![StateOfTheProject](https://raw.githubusercontent.com/hassanhabib/Standard.AI.Data.EntityIntelligence/main/stateoftheproject.drawio.png)
<a href="https://app.diagrams.net/#Hhassanhabib%2FStandard.AI.Data.EntityIntelligence%2Fmain%2Fstateoftheproject.drawio" target="_blank">Edit with Draw.io</a>-->

## How to use this library
![image](https://github.com/hassanhabib/Standard.AI.Data.EntityIntelligence/assets/1453985/c6d9f0c9-aa2f-4634-ae83-1ab2260fd50e)

### Nuget Package 
Project in development - [![Nuget](https://img.shields.io/nuget/v/Standard.AI.Data.EntityIntelligence?logo=nuget&color=blue)](https://www.nuget.org/packages/Standard.AI.Data.EntityIntelligence)

## How to Contribute
If you want to contribute to this project please review the following documents:
- [The Standard](https://github.com/hassanhabib/The-Standard)
- [C# Coding Standard](https://github.com/hassanhabib/CSharpCodingStandard)
- [The Team Standard](https://github.com/hassanhabib/The-Standard-Team)

If you have a question make sure you either open an issue or join our [The Standard Community](https://discord.com/invite/vdPZ7hS52X) discord server.

## Live-Sessions
Our live-sessions are scheduled on [The Standard Calendar](https://tinyurl.com/the-standard-calendar) make sure you adjust the time to your city/timezone to be able to join us.

We broadcast on multiple platforms:

[YouTube](https://www.youtube.com/@HassanHabib)

[LinkedIn](https://www.linkedin.com/in/hassanrezkhabib/)

[Twitch](https://www.twitch.tv/binhabib)

[Twitter](https://twitter.com/HassanRezkHabib)

[Facebook](https://www.facebook.com/hassan.rezk.habib)

### Past-Sessions
Here's our live sessions to show you how this library was developed from scratch:

[Standard.EntityIntelligence YouTube Playlist](https://www.youtube.com/watch?v=wzT8tiIg70o&list=PLan3SCnsISTSf0q3FDvFLngnVpmiMte3L)

### Important Notice
This library is a community effort.
