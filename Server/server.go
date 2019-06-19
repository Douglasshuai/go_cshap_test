package main

import (
	"context"
	"log"
	"net"

	"google.golang.org/grpc"
	pb "./Account"
)

const (
	port = ":50051"
)

// server is used to implement helloworld.GreeterServer.
type server struct{}

func (s *server) GetEmployeeName(ctx context.Context, in *pb.EmployeeNameRequest) (*pb.EmployeeName, error) {

	log.Printf("Received: %v", in.EmpId)

	return &pb.EmployeeName{FirstName: "Li ", LastName: "Hai "}, nil
}

func main() {

	lis, err := net.Listen("tcp", port)
	if err != nil {
		log.Fatalf("failed to listen: %v", err)
	}
	s := grpc.NewServer()
	pb.RegisterAccountServiceServer(s, &server{})
	err = s.Serve(lis)
	log.Println("Stop")
	
	if err != nil {
		log.Fatalf("failed to serve: %v", err)
	}
}
