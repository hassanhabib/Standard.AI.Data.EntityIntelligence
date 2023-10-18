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
[![](https://mermaid.ink/img/pako:eNqtVW1r4kAQ_itLiqeClZhEW0IpGGNBkL5cpF9MP6zJ2i6NG2-zXivF_97ZXdOsmh7HcQlodp6ZeeaZffuwkjwllm81Gh8xQ4gyKnykPhFqiheyIk0fNRe4IM2OaX3EnOJFRormlztAa05XmG9HeZZzGXc2Hsi3DK08ZuRdVF6u6566BDlPCa-cLkY2PIZfRhmp4HAgXwMuSJKz9KAa2x70DlIIwgU9cFkul00N7-Qf_OwajZgts_wtecFcoJ_TmMWMpnbXnrdCLLDsTfvJ9_0wQFfn59dIYj0FBTx_JbwtsbvbccwkLFFHoRHhv2lCShj9gMgeREYJNPgY1ZROxeCqHPc8T0hRUPZc4w_JkKbsAaVOWxswHM0mj2Oty5nPI4Fl49LukHbv1oQNJ09S33QSlBKcrt3SSL1EB2QMJycllaAD4B8q11rdSqs3jx6mDxvCt3ccVBSCY0Fztg98MhQoqUagUnRkkTZ3Pp9xzAqciOhX1o0STtcizFdXC349pQsOa-JYswuaoYx7zAvC62W7cvZKl1JWBToVeKpe1-WdrKky3AP679eUB8yqQcesHrAq4FvGrvvVXV1bbY9V06pGQpQOPrRIW__jFosNx1mZVfZ0lMNupsxMudPT7JUJ-vtqjLG0DFqt1iijhIl2W6oeTSfj25ki0goH0i_JcFGEZIn0QkBLmmX-2c3NsG_bHQRioGly7Bnj8zeaihffWb93UCIPAP_MVs-XQ4oL2PMcb30ERtugURtWk9j2pW2SHI5rSG7U8zckwZ4iHA77jkEBKcKL_yMEFvie5PJiNB4Hpg5QEvwTh9NBjsGhp2xPA2e9yRGYrajt1fcirI61InyFaQoXmLqEYktdTrHlwyccYa-xBQc4-OGNyKMtSyx_ibOCdKzNOsWChBQ_c7zaW3efbSI4ng?type=png)](https://mermaid.live/edit#pako:eNqtVW1r4kAQ_itLiqeClZhEW0IpGGNBkL5cpF9MP6zJ2i6NG2-zXivF_97ZXdOsmh7HcQlodp6ZeeaZffuwkjwllm81Gh8xQ4gyKnykPhFqiheyIk0fNRe4IM2OaX3EnOJFRormlztAa05XmG9HeZZzGXc2Hsi3DK08ZuRdVF6u6566BDlPCa-cLkY2PIZfRhmp4HAgXwMuSJKz9KAa2x70DlIIwgU9cFkul00N7-Qf_OwajZgts_wtecFcoJ_TmMWMpnbXnrdCLLDsTfvJ9_0wQFfn59dIYj0FBTx_JbwtsbvbccwkLFFHoRHhv2lCShj9gMgeREYJNPgY1ZROxeCqHPc8T0hRUPZc4w_JkKbsAaVOWxswHM0mj2Oty5nPI4Fl49LukHbv1oQNJ09S33QSlBKcrt3SSL1EB2QMJycllaAD4B8q11rdSqs3jx6mDxvCt3ccVBSCY0Fztg98MhQoqUagUnRkkTZ3Pp9xzAqciOhX1o0STtcizFdXC349pQsOa-JYswuaoYx7zAvC62W7cvZKl1JWBToVeKpe1-WdrKky3AP679eUB8yqQcesHrAq4FvGrvvVXV1bbY9V06pGQpQOPrRIW__jFosNx1mZVfZ0lMNupsxMudPT7JUJ-vtqjLG0DFqt1iijhIl2W6oeTSfj25ki0goH0i_JcFGEZIn0QkBLmmX-2c3NsG_bHQRioGly7Bnj8zeaihffWb93UCIPAP_MVs-XQ4oL2PMcb30ERtugURtWk9j2pW2SHI5rSG7U8zckwZ4iHA77jkEBKcKL_yMEFvie5PJiNB4Hpg5QEvwTh9NBjsGhp2xPA2e9yRGYrajt1fcirI61InyFaQoXmLqEYktdTrHlwyccYa-xBQc4-OGNyKMtSyx_ibOCdKzNOsWChBQ_c7zaW3efbSI4ng)

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
