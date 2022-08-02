#version 330

#define PI 3.141592653589793

in vec2 v_uv;
in vec3 v_direction;

uniform sampler2D u_envTexture;

out vec4 color;

float hypot (vec2 z) {
    float t;
    float x = abs(z.x);
    float y = abs(z.y);
    t = min(x, y);
    x = max(x, y);
    t = t / x;
    return (z.x == 0.0 && z.y == 0.0) ? 0.0 : x * sqrt(1.0 + t * t);
}

vec2 getEquirectangularUV(vec3 direction)
{
    vec2 uv;
    uv.x = -atan(direction.z, direction.x) / (2.0 * PI) + 0.5;
    uv.y = -atan(direction.y, hypot(direction.xz)) / PI + 0.5;
    return uv;
}

void main() { 
    
    color = texture(u_envTexture, getEquirectangularUV(v_direction));
    return;
    color = vec4 (1.0,0.0,0.0,1.0);
}