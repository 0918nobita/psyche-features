package main

import (
	"fmt"
	"io/ioutil"

	"cuelang.org/go/cue"
)

func main() {
	var runtime cue.Runtime

	source, _ := ioutil.ReadFile("example.cue")

	instance, _ := runtime.Compile("test", source)

	str, _ := instance.Lookup("msg").String()

	fmt.Println(str)
}
