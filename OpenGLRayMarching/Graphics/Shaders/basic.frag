#version 330

in vec3 v_direction;

out vec4 color;

void main() { 
    color = vec4(v_direction, 1.0);
    return;
    color = vec4 (1.0,0.0,0.0,1.0);
}