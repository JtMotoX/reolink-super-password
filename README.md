# Reolink Reset Code Helper

Build the image:

```sh
docker build -t reolink-reset-code .
```

Run it with the input code from your authorized NVR:

```sh
docker run --rm --network none reolink-reset-code "40287952"
```
