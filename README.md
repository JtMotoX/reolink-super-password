# Reolink Reset Code Helper

Build the image:

```sh
docker build -t reolink-reset-code .
```

Run it with the input code from your authorized NVR:

```sh
docker run --rm --network none reolink-reset-code "40287952"
```

## Credits

Algorithm based on exelix11's Reolink NVR super password gist:
https://gist.github.com/exelix11/94d1f87b66ce2468f67fa1f17b7bc829
