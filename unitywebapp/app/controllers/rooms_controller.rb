class RoomsController < ApplicationController
    def create
        puts params[:name]
        puts params[:age]
        @room = Room.new(name: params[:name], password: params[:password], floor_image_url: params[:floor_image_url])
        @room.save
    end
end
