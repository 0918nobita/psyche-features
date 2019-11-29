package main

import (
	"bytes"
	"fmt"
	"os"
	"os/exec"
)

func main() {
	cmd := "node"
	args := []string{"-v"}
	process := exec.Command(cmd, args...)
	stdin, err := process.StdinPipe()

	if err != nil {
		fmt.Println(err)
	}

	defer stdin.Close()

	buf := new(bytes.Buffer)
	process.Stdout = buf
	process.Stderr = os.Stderr

	if err = process.Start(); err != nil {
		fmt.Println("An error occured: ", err)
	}

	process.Wait()
	fmt.Println("Node.js version:", buf)
}
