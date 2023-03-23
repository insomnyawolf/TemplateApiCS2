# Devlog

## DatabaseDesign

Around 90 Minutes

## Backend Template

Everything from scratch around 8h

## Frontend Template

## Vite Fight +4h

Reason:

Configuring Debug Profiles

```
[32m[1mVITE[22m v4.2.1[39m  [2mready in [0m[1m281[22m[2m[0m ms[22m
[32m➜[39m  [1mLocal[22m:   [36mhttp://localhost:[1m5174[22m/[39m
[2m  [32m➜[39m  [1mNetwork[22m[2m: use [22m[1m--host[22m[2m to expose[22m
[2m[32m  ➜[39m[22m[2m  press [22m[1mh[22m[2m to show help[22m
```

Those colors break things and scripts

## Debugger Setup

2h

Got it running on VS-Code but on VisualStudio i have a error that i can't understand

```
2>------ Deploy started: Project: reactapp, Configuration: Debug Any CPU ------
2>Error reading JToken from JsonReader. Path '', line 0, position 0.
========== Build: 1 succeeded, 0 failed, 1 up-to-date, 0 skipped ==========
========== Build started at 7:14 AM and took 08,041 seconds ==========
========== Deploy: 0 succeeded, 1 failed, 0 skipped ==========
========== Deploy started at 7:14 AM and took 08,041 seconds ==========
```

Currently giving up on this for now and prioritizing development

## Development

2h

https://create-react-app.dev/docs/adding-typescript/

```
pnpm install -g create-react-app
```

```
create-react-app reactapp --template typescript
```

## Learn react basics and have a sample app with a router

Router is kinda confusing at first, but once you get the hang of it it becames easy 4h


## Api CLients from openapi spec

```
pnpm add --save-dev openapi-typescript openapi-typescript-codegen
```

```
pnpm openapi -i http://localhost:5000/swagger/v1/swagger.json -o src/services/openapi
```

that was awesome O:

## 