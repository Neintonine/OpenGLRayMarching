#version 330

layout(location = 0) in vec3 a_Position;

uniform vec3 u_cameraPosition;
uniform mat4 u_mvp;
uniform mat4 u_model;

out vec3 v_direction;

void main() {

    v_direction = normalize((u_model * vec4(a_Position, 1.0)).xyz - u_cameraPosition);
    
    gl_Position = u_mvp * vec4(a_Position, 1.0);
}