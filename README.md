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

```mermaid
flowchart RL
id0.0[(Database)]:::DB <--> id0.1(DataBroker):::DONE
<-->id0.2(DataService):::DONE & id1.1(SchemaService):::DONE

id0.2 <--> id0.3(DataProcessingService):::DONE


id1.1 <-->id1.2(SchemaProcessingService):::CURRENT

id2[[Standard.Ai.OpenAI]]:::LIB
<-->id2.0(OpenAIBroker):::DONE
<-->id2.1(AIService):::DONE
<-->id2.2(AIProcessingService):::DONE

id0.3 <--> id0.4[SQLQueryOrchestrationService]:::CURRENT
id1.2 <--> id0.4
id2.2 <--> id0.4

id3[[TransactSql.ScriptDom<br>Library]]:::LIB
<-->id3.0(SQLParserBroker):::DONE
<-->id3.1(SQLParserService)
<-->id3.2(SQLParserProcessingService)

id4[(Database)]:::DB
<-->id4.0(DataBroker):::DONE
<-->id4.1(QueryService)
<-->id4.2(QueryProcessingService)

id4.3[SQLQueryParserOrchestrationService]
id3.2 <--> id4.3
id4.2 <--> id4.3

id5{NaturalSQLQuery<br>CoordinationService}
id0.4 <--> id5
id4.3 <--> id5
id6(((Client))):::CLIENT
id5<-->id6

classDef DONE fill:#008000, stroke:#008000, stroke-width:2px, color:#FFFFFF, stroke-dasharray: 0, 0
classDef DB fill:#DAA520, stroke:##FFD700, stroke-width:2px, color:#000000, stroke-dasharray: 0, 0
classDef LIB fill:#87CEEB, stroke:#00008B, stroke-width:2px, color:#000000, stroke-dasharray: 2, 2
classDef CURRENT fill:#FFA500, stroke:#FF4500, stroke-width:2px, color:#000000, stroke-dasharray: 0, 0
classDef CLIENT fill:#FFFAFA, stroke:#2F4F4F, stroke-width:2px, color:#4B0082, stroke-dasharray: 0, 0 
```
#

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
