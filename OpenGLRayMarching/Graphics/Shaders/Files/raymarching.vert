#version 330

layout(location = 0) in vec3 a_Position;
layout(location = 1) in vec2 a_uv;

uniform vec3 u_cameraPosition;
uniform mat4 u_mvp;
uniform mat4 u_model;

out vec3 v_direction;
out vec2 v_uv;

void main() {

    v_uv = a_uv;
    v_direction = normalize((u_model * vec4(a_Position, 1.0)).xyz - u_cameraPosition);
    
    gl_Position = u_mvp * vec4(a_Position, 1.0);
}